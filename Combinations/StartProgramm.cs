using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinations.Classes;
using Combinations.Data;
using Combinations.Interfaces;
using Ninject;

namespace Combinations
{
    class StartProgramm
    {
        private const string InputFileDefault = @"./input.xml"; //= @"C:\input.xml";
        private const string OutputFileDefault = @"./output.xml";

        static void GetArgs(string[] args, out string inputFile, out string outputFile)
        {
            inputFile = InputFileDefault;
            outputFile = OutputFileDefault;
            if (args.Length > 0)
                inputFile = args[0];
            if (args.Length > 1)
                inputFile = args[1];
        }

        public static StandardKernel DIConteiner { get; private set; } 
        static void Build(string input, string output)
        {
            DIConteiner = new StandardKernel();
            DIConteiner.Bind<IInputDataSource>().To<FileXmlDataSource>()
                .WithConstructorArgument("input", input);
            DIConteiner.Bind<ICombination>().To<SimpleCombination>();
            DIConteiner.Bind<IOutputDataAccept>().To<OutputDataAcceptToXml>()
                .WithConstructorArgument("output", output);
            DIConteiner.Bind<Program>().ToSelf();
        }
        static void Main(string[] args)
        {
            string input, output;
            GetArgs(args, out input, out output);
            Build(input, output);
            var program = DIConteiner.Get<Program>();
            try
            {
                program.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }


    }
}
