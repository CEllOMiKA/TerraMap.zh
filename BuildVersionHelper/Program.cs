using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuildVersionHelper
{
	class Program
	{
		static Version version;

		static string[] assemblyInfoFilenames = {
			@"TerraMap\Properties\AssemblyInfo.cs",
			@"Console\Properties\AssemblyInfo.cs",
			@"Data\Properties\AssemblyInfo.cs",
		};

		static void Main(string[] args)
		{
			Initialize(args);
			UpdateAssemblyInfoFiles();
		}

		static void Initialize(string[] args)
		{
			if (args == null || args.Length < 1)
			{
				Console.WriteLine("{0} [版本号]", Assembly.GetExecutingAssembly().GetName());
				Environment.Exit(1);
			}

			version = new Version(args[0]);
		}

		static void UpdateAssemblyInfoFiles()
		{
			Console.WriteLine("正在更新程序集版本号");

			// read the current version from the assemblyinfo files
			foreach (var assemblyInfoFilename in assemblyInfoFilenames)
			{
				string text = File.ReadAllText(assemblyInfoFilename, Encoding.UTF8);
				Regex regex = new Regex("\\d+\\.\\d+\\.\\d+", RegexOptions.CultureInvariant | RegexOptions.Compiled);
				Match m = regex.Match(text);
				if (!m.Success)
					throw new Exception("无法在 AssemblyInfo.cs 文件中找到版本号");

				// replace the version in the file with our version
				text = regex.Replace(text, version.ToString(3));

				File.WriteAllText(assemblyInfoFilename, text, Encoding.UTF8);
			}
		}

	}
}
