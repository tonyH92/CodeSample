// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;


public class Generic<T>
{
    public T MyField;
    public void test()
    {
        //T i = MyField + 1;
    }
}
class program
{

    public class JsonModel
    {
        public string version { get; set; }
        public string title { get; set; }
    }

    public class product
    {
        public List<JsonModel> products { get; set; }
    }


    abstract class animals
    {
        public string Name;

        public abstract string Speak();
    }

    class dog : animals
    {
        public override string Speak()
        {
            return "Woof";
        }

    }

    class cat : animals
    {
        public override string Speak()
        {
            return "Meow";
        }
    }

    static void Main(string[] args)
    {
        Generic<int> t = new Generic<int>();
        t.test();

        int[] intArray = { 1, 2, 3 };

        //solution(intArray);
        //GetHttpRequest(); 
        //testing();
        //Console.WriteLine(testing2());

        //question1();
        question2(); 

        int testing2()
        {
            int v1h1 = 0, v1h2 = 0, v1h3 = 0, v1h4 = 0, v1h5 = 0;
            int v2h1 = 0, v2h2 = 0, v2h3 = 0, v2h4 = 0, v2h5 = 0;

            string version1 = "2.0", version2 = "2.0.0.0.1";

            int[] v1List = { 0, 0, 0, 0, 0 };
            var v1al = version1.Split('.').ToList().ConvertAll(int.Parse).ToArray();

            for (int i = 0; i < v1al.Count(); i++)
            {
                v1List[i] = v1al[i];
            }


            int[] v2List = { 0, 0, 0, 0, 0 };
            var v2al = version2.Split('.').ToList().ConvertAll(int.Parse).ToArray();

            for (int i = 0; i < v2al.Count(); i++)
            {
                v2List[i] = v2al[i];
            }

            Console.WriteLine(string.Join('.', v1List));
            Console.WriteLine(string.Join('.', v2List));



            if (string.Join('.', v1List) == string.Join('.', v2List))
                return 0;


            for (int i = 0; i < v1List.Count(); i++)
            {
                if (v1List[i] == v2List[i])
                {
                    continue;
                }

                if (v1List[i] > v2List[i])
                {
                    return 1;
                }
                if (v1List[i] < v2List[i])
                {
                    return -1;
                }

            }

            return 0;
        }

        int testing()
        {
            int v1h1 = 0, v1h2 = 0, v1h3 = 0, v1h4 = 0, v1h5 = 0;
            int v2h1 = 0, v2h2 = 0, v2h3 = 0, v2h4 = 0, v2h5 = 0;

            string version1 = "2.0", version2 = "2.0.0.0.0";

            int[] v1 = { 0, 0, 0, 0, 0};
            var v1al = version1.Split('.').ToList().ConvertAll(int.Parse).ToArray();

            for(int i = 0; i < v1al.Count(); i++)
            {
                v1[i] = v1al[i];
            }


            List<int> v1List = new List<int>();
            v1List = versionCleanUp(version1); 

            //Console.WriteLine(string.Join('.', v1List));

            List<int> v2List = new List<int>();
            v2List = versionCleanUp(version2);

            if (string.Join('.', v1List) == string.Join('.', v2List))
                return 0; 


            for(int i = 0; i < v1List.Count(); i++)
            {
                if (v1List[i] == v2List[i])
                {
                    continue;
                }

                if (v1List[i] > v2List[i])
                {
                    return 1;
                }
                if (v1List[i] > v2List[i])
                {
                    return -1;
                }

            }

            return 0; 
        }

        List<int> versionCleanUp(string value)
        {
            List<int> vList = new List<int>();
            if(string.IsNullOrEmpty(value))
            {
                value = "0";
            }
            vList = value.Split('.').ToList().ConvertAll(int.Parse);

            //Console.WriteLine(vList.Count);
            if (vList.Count() != 5)
            {
                for (int i = 0; i <= 5 - vList.Count() + 1; i++)
                {
                    vList.Add(0);
                }
            }

            return vList; 
        }

        void solution(int[] a)
        {
            Console.WriteLine("Hello, World!");
        }

        void GetHttpRequest()
        {
            //Console.WriteLine();
            //https://github.com/Ovi/DummyJSON
            //https://stackoverflow.com/questions/4015324/send-http-post-request-in-net

            HttpClient client = new HttpClient();

            var request = (HttpWebRequest)WebRequest.Create("https://dummyjson.com/products");

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //Console.WriteLine(responseString + "\r\n");

            var JsonData = JsonSerializer.Deserialize<product>(responseString);

            Console.WriteLine(JsonData.products[0].title);


            // Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.
            //HttpResponseMessage response = client.GetAsync("api/Values").Result;  // Blocking call!
            //using HttpResponseMessage response = client.GetStreamAsync(client.BaseAddress).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    //var products = response.Content.ReadAsStringAsync().Result;
            //    var productsJSON = JsonSerializer.Deserialize<JsonModel>(response.Content.ReadAsStringAsync().Result);
            //    Console.WriteLine(productsJSON.version);

            //    Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
            //    Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}
            Console.ReadLine();
        }


        void question1()
        {
            /*
            1.	Prints the numbers from 1 to 100. But for multiples of three print “Fizz” instead of the number and for the multiples 
        of five print “Buzz”. For numbers which are multiples of both three and five print “FizzBuzz.

             */

            int start_index = 1, end_index = 100;

            for (int i = start_index; i <= end_index; i++)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }


        void question2()
        {
            /*
            2.	Using an object oriented programming approach; create a class or classes which represent animals.  The animal has the property Name 
                and the method Speak().  The method Speak() will return “Woof” if it is a dog or “Meow” if it is a cat.  The cat and dog will inherit the 
                method Speak() appropriately. 
                Test your program by creating a list or array, populate it with dogs and cats, and then call each member’s name and the Speak() method.
                Your output should be something like this:
                 
                Here is Robby: Woof!
                Here is Fifi: Woof!
                Here is Mimi: Meow! 
            */

            List<animals> animals = new List<animals>();
            animals.Add(new dog() { Name = "Robby" });
            animals.Add(new dog() { Name = "Fifi" });
            animals.Add(new cat() { Name = "Mimi" });


            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine("Here is " + animals[i].Name + ": " + animals[i].Speak() + "!");
            }


        }

    }

}
