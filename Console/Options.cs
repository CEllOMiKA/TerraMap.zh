using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraMap
{
	public class Options
	{
		[Option('i', "input", Required = true, HelpText = "要处理的输入wld文件。")]
		public string InputFile { get; set; }
		
		[Option('o', "output", Required = true, HelpText = "要创建/覆盖的输出png文件。")]
		public string OutputFile { get; set; }

		[OptionList('t', "tileId", Required = false, HelpText = "要高亮显示的方块ID号，用分号分隔（-t \"1;2;3\"）。", Separator = ';')]
		public IEnumerable<string> TileIds { get; set; }

		[OptionList('m', "itemId", Required = false, HelpText = "要高亮显示的物品ID号，用分号分隔（-m \"1;2;3\"）。", Separator = ';')]
		public IEnumerable<string> ItemIds { get; set; }

		[OptionList('n', "name", Required = false, HelpText = "要高亮显示的方块和/或物品名称，用分号分隔（-n \"Ebonstone;Ebonsand;Corrupted Vine\"）。", Separator = ';')]
		public IEnumerable<string> Names { get; set; }

		[ParserState]
		public IParserState LastParserState { get; set; }

		[HelpOption]
		public string GetUsage()
		{
			var help = HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
			help.AddPostOptionsLine("示例:\n");
			help.AddPostOptionsLine("terramapcmd -i \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.wld\" -o \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.png\"\n");
			help.AddPostOptionsLine("terramapcmd -i \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.wld\" -o \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.png\" -n \"Ebonstone;Ebonsand;Corrupted Vine\"\n");
			help.AddPostOptionsLine("terramapcmd -i \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.wld\" -o \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.png\" -t \"23;25;32\"\n");
			help.AddPostOptionsLine("terramapcmd -i \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.wld\" -o \"C:\\Users\\Jason\\Documents\\My Games\\Terraria\\Worlds\\World1.png\" -m \"23;25;32\"\n");

			return help;
		}
	}
}
