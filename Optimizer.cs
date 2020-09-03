using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _2dLayoutOptimizer
{
    public class Optimizer
    {
        enum OptimizationPreference{ FewestSheets, SamePartAdjacent, SameDimensionAdjacent, FewestCuts, FewestWastePieces }
        public static CutSheet[] Optimize(Job job)
        {
            if (job.Skus.Any(x => x.Length > job.SheetLength || x.Width > job.SheetWidth))
                throw new ApplicationException("some parts are too big for the sheet size");

            //OptimizationPreference[] optimizationRanking = { OptimizationPreference.FewestSheets, OptimizationPreference.SamePartAdjacent, OptimizationPreference.SameDimensionAdjacent, OptimizationPreference.FewestCuts };
            
            List<Segment> rootSegments = new List<Segment>();
            Segment.KerfWidth = job.KerfWdith;

            List<SkuUnit> unitsToFit = new List<SkuUnit>();
            foreach (var sku in job.Skus.OrderByDescending(x => x.CanRotate && x.Width > x.Length ? x.Width : x.Length)
                .ThenByDescending(x => x.CanRotate && x.Width > x.Length ? x.Length : x.Width))
            {
                for(int i = 0; i < sku.Qty; i++)
                {
                    unitsToFit.Add(new SkuUnit(sku));
                }
            }
            
            while (unitsToFit.Count > 0)
            {
                List<Solution> solutions = new List<Solution>();

                //limit the number of possible solutions by only testing each distinct sku
                foreach (var skuToFit in unitsToFit.GroupBy(x => x.Sku).Select(x=>x.First().Sku))
                {
                    //add the solution
                    solutions.AddRange(BuildTestSolutions(rootSegments, unitsToFit, skuToFit, job.SheetLength, job.SheetWidth));
                }
                var bestSolution = solutions
                    .OrderBy(x => x.TotalLength())
                    .ThenByDescending(x => x.WasteCount())
                    .First();

                PlaceUnit(rootSegments, bestSolution.UnitPlaced, job.SheetLength, job.SheetWidth);
                var unitToRemove = unitsToFit.Where(x => x.Sku == bestSolution.UnitPlaced.Sku).First();
                unitsToFit.Remove(unitToRemove);
            }

            List<CutSheet> cutSheets = new List<CutSheet> { new CutSheet { Length = job.SheetLength, Width = job.SheetWidth } };
            rootSegments = rootSegments.OrderByDescending(x => x.Length).ThenByDescending(x => x.UsedArea).ToList();

            while (rootSegments.Count > 0)
            {
                var segmentToPlace = rootSegments.First();
                bool segmentPlaced = false;
                {
                    foreach (CutSheet sheet in cutSheets)
                    {
                        if (sheet.TryFitSegment(segmentToPlace))
                        {
                            segmentPlaced = true;
                            break;
                        }
                    }
                    //segment did not fit on any existing sheet
                    if (!segmentPlaced)
                        cutSheets.Add(new CutSheet { Length = job.SheetLength, Width = job.SheetWidth });
                    else
                        rootSegments.Remove(segmentToPlace);
                }

            }
            //rearange the segments and sheets by density
            foreach (CutSheet sheet in cutSheets)
            {
                sheet.Segments.Sort((y, x) => (x.UsedArea / ((float)(x.Length * x.Width))).CompareTo(y.UsedArea / ((float)(y.Length * y.Width))));
            }
            cutSheets.Sort((y,x) => (x.Segments.Sum(z => z.UsedArea) / ((float)(x.Length * x.Width))).CompareTo(y.Segments.Sum(z => z.UsedArea) / ((float)(y.Length * y.Width))));
            return cutSheets.ToArray();
        }
        private static List<Solution> BuildTestSolutions(List<Segment> currentSegments, List<SkuUnit> unitsToFit, Sku skuToTry, int sheetLength, int sheetWidth)
        {
            List<Solution> solutions = new List<Solution>();
            //pick a unit from the sku to try first
            var skuUnit = unitsToFit.Where(x => x.Sku == skuToTry).First();

            //set up a clone of the remaining items with the one to test first
            var subProblemUnitsToFit = unitsToFit.Where(x => x != skuUnit).Select(x => x.Clone()).ToList();
            subProblemUnitsToFit.Insert(0, skuUnit.Clone());

            //clone the segments so we can test the subproblem in isolation
            var subProblemRootSegments = currentSegments.Select(x => x.Clone()).ToList();

            solutions.Add(BuildSolution(subProblemRootSegments, subProblemUnitsToFit, sheetLength, sheetWidth));

            if(skuToTry.CanRotate && skuToTry.Length <= sheetWidth && skuToTry.Width <= sheetWidth)
            {
                var subProblemUnitsToFitRotated = unitsToFit.Where(x => x != skuUnit).Select(x => x.Clone()).ToList();
                var skuUnitRotated = skuUnit.Clone();
                skuUnitRotated.Rotate();

                subProblemUnitsToFitRotated.Insert(0, skuUnitRotated);

                //clone the segments so we can test the subproblem in isolation
                var subProblemRootSegmentsRotated = currentSegments.Select(x => x.Clone()).ToList();

                solutions.Add(BuildSolution(subProblemRootSegmentsRotated, subProblemUnitsToFitRotated, sheetLength, sheetWidth));
            }
            return solutions;
        }
       
        private static void PlaceUnit(List<Segment> currentSegments, SkuUnit unitToFit, int sheetLength, int sheetWidth)
        {
            var subProblemUnitsToFit = new List<SkuUnit> { unitToFit };
            BuildSolution(currentSegments, subProblemUnitsToFit, sheetLength, sheetWidth);
        }

        private static Solution BuildSolution(List<Segment> subProblemRootSegments, List<SkuUnit> subProblemUnitsToFit, int sheetLength, int sheetWidth)
        {
            var solution = new Solution { UnitPlaced = subProblemUnitsToFit.First() };
            bool isFirst = true;
            while (subProblemUnitsToFit.Count() > 0)
            {
                var currentUnitToFit = subProblemUnitsToFit.First();

                bool skuUnitPlaced = false;
                foreach (var segment in subProblemRootSegments)
                {
                    if (segment.TryFitSkuUnit(currentUnitToFit, !isFirst))
                    {
                        skuUnitPlaced = true;
                        break;
                    }
                }
                //a part did not fit, start a new rootSegment
                if (!skuUnitPlaced)
                    subProblemRootSegments.Add(new Segment { Length = currentUnitToFit.Length, Width = sheetWidth });
                else
                {
                    subProblemUnitsToFit.Remove(currentUnitToFit);
                    //all after the first are allowed to rotate
                    isFirst = false;
                }
            }
            solution.Segments = subProblemRootSegments;
            return solution;
        }
    }
}

