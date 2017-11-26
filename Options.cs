using CommandLine;
using CommandLine.Text;

// NOTE: This is mostly generated code from the Command Line Parser.
namespace Grade_Scores
{
    public class Options
    {
        [Option('i', "Input", Required = true, HelpText = "The input file to be read from.")]
        public string InputFile { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}