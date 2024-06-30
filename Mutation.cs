using System.Diagnostics;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Runner.UnityApp.Car;
using GeneticSharp.Domain.Randomizations;

public class Mutation : IMutation
{
    public bool IsOrdered { get; private set; } // indicating whether the operator is ordered (if can keep the chromosome order).

    public Mutation()
    {
        IsOrdered = true;
    }

    public void Mutate(IChromosome chromosome, float probability)
    {
        
        /* YOUR CODE HERE */
        CarChromosome newChromosome = new CarChromosome(((CarChromosome)chromosome).getConfig());
        for (int i = 0; i < chromosome.Length; i++)
        {
            if (RandomizationProvider.Current.GetDouble() <= probability)
            {
                chromosome.ReplaceGene(i, newChromosome.GenerateGene(i));
            }
        }
        /*END OF YOUR CODE*/
    }

}
