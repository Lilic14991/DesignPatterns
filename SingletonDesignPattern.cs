using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i <= 2; i++)
            {
                Model.Instance.ShowDetails();
            }

            Console.ReadKey();

        }


    }


    public class Model
    {

        private static Model instance = null;
        private string modelName { get; set; }
        private string transformPosition { get; set; }
        private string animation { get; set; }
        private string texture { get; set; }
        private string color { get; set; }
        private int numberOfComponents { get; set; }


        private Model()
        {
            modelName = "Model1";
            transformPosition = "0, 50, -20";
            animation = "animation 1";
            texture = "rock";
            color = "black";
            numberOfComponents = 2;
        }

        private static object syncLock = new object();

        public static Model Instance
        {
            get
            {
                lock(syncLock)
                {
                    if(instance == null)
                    {
                        instance = new Model();
                    }
                }
                return instance;
            }
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Model: {modelName} has {transformPosition} transform posion" +
                $" with: animation: {animation}; texture:{texture}; color: {color} and number of {numberOfComponents} components.");
        }


    }
}
