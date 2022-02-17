namespace OnePizzaNet5
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    public class FileReader
    {
        private const char Delimiter = ' ';
        
        public static List<Client> Get(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception("File is missing");
            }

            var content = File.ReadAllLines(path);

            var noClients = int.Parse(content[0]);

            var clients = new List<Client>(noClients);
            
            for (int clientIndex = 1; clientIndex < content.Length; clientIndex += 2)
            {
                clients.Add(new Client()
                {
                    Likes = new List<string>(content[clientIndex].Split(Delimiter)),
                    Dislikes = new List<string>(content[clientIndex + 1].Split(Delimiter))
                });
            }

            return clients.ToList();
        }
    }
}
