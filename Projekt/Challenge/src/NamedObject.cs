namespace Challenge
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }
        public string Name 
        {get;set;} 

        public void WriteString(string String)
        {   
            Console.WriteLine(String);
            Console.WriteLine("String");
            Console.WriteLine("lol its works");
        }
    }
}