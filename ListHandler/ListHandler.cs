using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Basic
{
    class ListHandler<T>
    {
        //Properties
        private List<T> list=new List<T>();
        private Color color;
        private DateTime created;
        
        //Color Structure
        struct Color
        {
            int red;
            int green;
            int blue;

            public Color(int red, int green, int blue)
            {
                this.red = red;
                this.green = green;
                this.blue = blue;
            }
        }

        //Constructor
        public ListHandler(int size,int r,int g,int b)
        {
            color = new Color(r,g,b);
            generateList(size);
        }

        //Generate list
        public void generateList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                list.Add((T)Convert.ChangeType(i, typeof(T)));
            }
            created =DateTime.Now;
        }

        //Save list to file
        public void writeToFile(string path)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                foreach(T row in list)
                {
                    writer.WriteLine(row);
                }
            }
        }

        //Load list from file
        public void readFromFile(string path)
        {
            try
            {
                using (TextReader reader = new StreamReader(path))
                {
                    list.Clear();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add((T)Convert.ChangeType(line, typeof(T)));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //Print the list in color
        public void printList()
        {
            Console.WriteLine("List type: " + typeof(T).Name);
            Console.WriteLine("List created: " + created);
            Console.WriteLine("List elements:");
            Console.ForegroundColor = ConsoleColor.Blue;

            foreach(T row in list)
            {
                Console.WriteLine(row);
            }
            Console.ResetColor();
        }
    }
}
