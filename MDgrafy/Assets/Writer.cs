using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDgrafy.Assets
{
    public static class Writer
    {
        public static async Task GenerateRaport()
        {
            //Czyszczenie pliku przed zapisem
            File.WriteAllText("raport.txt",String.Empty);
            //Zapis
            using StreamWriter file = new("raport.txt", append: true);
            await file.WriteLineAsync("Raport z wygenerowanego grafu\n\n" + "Dane: \n");
            await file.WriteLineAsync("G = ( V, E )\n\n" + "Zbiór krawędzi i punktów:\n" + Edge.ShowEdges() + Vertex.ShowVertexes() + "\n\n" + "Zbiór połączeń:\n" + Edge.ShowConnections() + "\n\n" + "Zbiór wag dla poszczególnych połączeń\n\n" + Vertex.ShowDegrees() + "\n\n" + Edge.ShowWeights() + "\n\n");
            await file.WriteLineAsync("Znalezione cykle 3:\n" + Cycle.ShowCycles3());

            MessageBox.Show($"Raport aplikacji został zapisany w: \n {Directory.GetCurrentDirectory()}", "Raport aplikacji");
        }
    }
}
