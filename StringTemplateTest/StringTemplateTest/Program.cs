
using Antlr4.StringTemplate;
using Antlr4.StringTemplate.Misc;
namespace Testing
{
    class Program
    {
        static int Main(string[] args)
        {

            List<Test> tests = new List<Test>();
            tests.Add(new Test(true, "a"));
            tests.Add(new Test(false, "b"));
            tests.Add(new Test(true, "c"));
            tests.Add(new Test(true, "d"));
            tests.Add(new Test(true, "e"));
            tests.Add(new Test(false, "f"));
            tests.Add(new Test(false, "g"));
            tests.Add(new Test(false, "h"));


            var templateContents = File.ReadAllText(@"template.st4");
            TemplateGroup templateGroup = new TemplateGroup('$', '$');
            Template template = new Template(templateGroup, templateContents);

            template.Add("Tests", tests);

            File.WriteAllText("TemplateFilled.txt", template.Render());

            return 0;
        }
    }

    class Test
    {
        public bool IsTrue { get; set; }
        public string Value { get; set; }
        public List<string> Values { get { return new List<string>() { "a", "b", "c", "d", "d", "f"}; } }

        public Test(bool isTrue, string value)
        {
            IsTrue = isTrue;
            Value = value;
        }
    }

}