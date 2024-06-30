using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Infrastructure.Framework.Texts;
using GeneticSharp.Runner.UnityApp.Car;
using UnityEngine;

public class ParentSelection : SelectionBase
{
    private int tournamentSize;
    public ParentSelection(int tournamentSize) : base(2)
    {
        this.tournamentSize = tournamentSize;
    }




    protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
    {

        IList<CarChromosome> population = generation.Chromosomes.Cast<CarChromosome>().ToList();
        IList<IChromosome> parents = new List<IChromosome>();
        
        /* YOUR CODE HERE */
        while (parents.Count < number)
        {
            int[] randomIndexes = RandomizationProvider.Current.GetUniqueInts(tournamentSize, 0, population.Count);
            int bestIndex = randomIndexes[0];
            for (int i = 1; i < tournamentSize; i++)
            {
                if (population[randomIndexes[i]].Fitness > population[bestIndex].Fitness)
                {
                    bestIndex = randomIndexes[i];
                }
            }
            parents.Add(population[bestIndex]);
        }
        /*END OF YOUR CODE*/

        return parents;
    }
}
