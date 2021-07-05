using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ZeroMunge.Modules
{
	/// <summary>
	/// Object used to create .lvl files 'on the fly' 
	/// </summary>
	/// <example>
	/// Munger dude = new Munger();
	///	dude.AddItem("C:\\path\\to\\script1.lua");
	///	dude.AddItem("C:\\path\\to\\script2.script");
	///	dude.AddItem("C:\\path\\to\\image1.tga");
	///	dude.AddItem("C:\\path\\to\\image2.texture");
	/// bool deleteWorkspace = true;
	/// string result = dude.CreateLvl("C:\\path\\to\\Dest\\", "output.lvl", "PC", deleteWorkspace);
	///	if(result.StartsWith("Error"))
	///		Console.WriteLine("There was an error:\n\t" + result);
	///	else 
	///		Console.WriteLine("Successful munge! saved to "+ result);
	/// </example>
	public class Munger
	{
		private Logger logger_dude = null;
		public Munger(Logger dude)
		{
			logger_dude = dude;
		}

		private void Log(string message)
		{
			if (logger_dude != null)
				logger_dude.Log(message, LogType.Info);
		}

		List<MungableItem> list_mungableItems = new List<MungableItem>();

		private string str_modToolsDir = null;
		private string ModToolsDir
		{
			get
			{
				if (str_modToolsDir == null)
				{
					Prefs prefs = Utilities.LoadPrefs();
					str_modToolsDir = prefs.ModToolsLocation;
					if (!str_modToolsDir.EndsWith("\\"))
						str_modToolsDir += "\\";
				}
				return str_modToolsDir;
			}
		}

		public bool AddItem(string file)
		{
			bool retVal = false;
			if (file.EndsWith(".lua", StringComparison.InvariantCultureIgnoreCase) ||
				 file.EndsWith(".tga", StringComparison.InvariantCultureIgnoreCase) ||
				 file.EndsWith(".script", StringComparison.InvariantCultureIgnoreCase) ||
				 file.EndsWith(".texture", StringComparison.InvariantCultureIgnoreCase) ||
				 file.EndsWith(".config", StringComparison.InvariantCultureIgnoreCase) ||
				 file.EndsWith(".mcfg", StringComparison.InvariantCultureIgnoreCase) ||
				 file.EndsWith(".lvl", StringComparison.InvariantCultureIgnoreCase)
				)
			{
				MungableItem dude = new MungableItem(file);
				list_mungableItems.Add(dude);
				retVal = true;
			}
			return retVal;
		}


		private bool AlreadyMunged(string filename)
		{
			string[] alreadyMungedExt = new string[] { ".texture", ".script", ".lvl", ".config" };
			foreach (string ext in alreadyMungedExt)
			{
				if (filename.ToLower().EndsWith(ext))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Creates a .lvl file with the contents added with (AddItem)
		/// </summary>
		/// <param name="outputPath">The directory to save the .lvl to</param>
		/// <param name="saveFileName">The name of the .lvl</param>
		/// <param name="platform">The platform for which to Munge.</param>
		/// <returns>
		///    The path to the saved file on success, a string starting with 'Error' on failure.
		/// </returns>
		public string CreateLvl(string outputPath, string saveFileName, string platform, bool deleteWorkspace)
		{
			string retVal = "";
			if (!outputPath.EndsWith("\\"))
				outputPath += "\\";

			string workspace = outputPath + ".\\__ZeroMunge__workspace__\\";
			string munge_dir = outputPath + ".\\__ZeroMunge__workspace__\\MUNGED\\";
			string saveFilePath = outputPath + saveFileName;
			try
			{
				if (Directory.Exists(workspace))
				{
					Directory.Delete(workspace, true);
				}
				Directory.CreateDirectory(workspace);
				Directory.CreateDirectory(munge_dir);
				string reqContent = GetReqString();
				string reqFileName = saveFileName.ToLower().Replace(".lvl", ".req");
				File.WriteAllText(workspace + reqFileName, reqContent);

				// now copy the files over to the workspace
				foreach (MungableItem item in list_mungableItems)
				{
					if (AlreadyMunged(item.Path))
						File.Copy(item.Path, munge_dir + item.FileName);
					else
						File.Copy(item.Path, workspace + item.FileName);
				}
				// now munge & pack

				string configMunge = ModToolsDir + "ToolsFL\\bin\\ConfigMunge.exe";
				string textureMunge = ModToolsDir + "ToolsFL\\bin\\pc_TextureMunge.exe";
				string scriptMunge = ModToolsDir + "ToolsFL\\bin\\ScriptMunge.exe";
				string lvlPack = ModToolsDir + "ToolsFL\\bin\\levelpack.exe";

				string req_file_noext = reqFileName.Replace(".req", "");
				string configArgs = string.Format(
									" -inputfile $*.mcfg -continue  -QUIET -platform {0} -sourcedir  {1} -outputdir {2} -hashstrings ",
									platform, workspace, munge_dir);
				string scriptArgs = string.Format(
									" -inputfile *.lua -continue  -QUIET -platform {0} -sourcedir  {1} -outputdir {2} ",
									platform, Path.GetFullPath(workspace), munge_dir);
				string texArgs = string.Format(
									" -inputfile $*.tga -checkdate -continue -QUIET -platform {0} -sourcedir  {1} -outputdir {2}  ",
									platform, workspace, munge_dir);
				string lvlPackArgs = string.Format(
									"-inputfile {0}.req -writefiles {1}{0}.files -continue -QUIET -platform {2} -sourcedir  {3} -inputdir {1} -outputdir {3}  ",
									req_file_noext, munge_dir, platform, Path.GetFullPath(workspace));
				//string programOutput = Program.RunCommand(program_exe, args, true);
				string programOutput = "";

				Log(String.Format("Calling: {0} {1}", scriptMunge, scriptArgs));
				programOutput += ProcessManager.RunCommandAndGetOutput(scriptMunge, scriptArgs, true);
				Log(String.Format("Calling: {0} {1}", configMunge, configArgs));
				programOutput += ProcessManager.RunCommandAndGetOutput(configMunge, configArgs, true);
				Log(String.Format("Calling: {0} {1}", textureMunge, texArgs));
				programOutput += ProcessManager.RunCommandAndGetOutput(textureMunge, texArgs, true);
				Log(String.Format("Calling: {0} {1}", lvlPack, lvlPackArgs));
				programOutput += ProcessManager.RunCommandAndGetOutput(lvlPack, lvlPackArgs, true);
				string batchFileContents = string.Format(
					"{0} {1}\n\n{2} {3}\n\n{4} {5}\n\n{6} {7}\n\n",
					textureMunge, String.Format("-inputfile $*.tga  -checkdate -continue -platform {0} -sourcedir . -outputdir MUNGED ", platform),
					scriptMunge, String.Format("-inputfile *.lua   -continue -platform {0} -sourcedir  . -outputdir MUNGED  ", platform),
					configMunge, String.Format("-inputfile $*.mcfg -continue -platform {0} -sourcedir . -outputdir MUNGED -hashstrings ", platform),
					lvlPack, String.Format("-inputfile {0}.req -writefiles MUNGED\\{0}.files -continue -platform {1} -sourcedir  . -inputdir MUNGED\\ -outputdir . ",
													req_file_noext, platform)
					);
				// copy output to user's choice directory
				string lvlOutput = workspace + req_file_noext + ".lvl";
				if (File.Exists(lvlOutput))
				{
					File.WriteAllText(workspace + "munge.bat", batchFileContents);
					File.WriteAllText(workspace + "munge.log", programOutput);
					File.Copy(lvlOutput, saveFilePath, true);
					retVal = saveFilePath;
					if (Directory.Exists(workspace) && deleteWorkspace)
					{
						Log("Deleting temp workspace: " + workspace);
						Directory.Delete(workspace, true);
					}
					Log("Successful creation of " + retVal);
				}
				else
				{
					retVal = "Error creating lvl file :\n" + programOutput;
				}
			}
			catch (Exception e)
			{
				retVal = "Error!" + e.Message;
			}
			return retVal;
		}

		private string GetReqString()
		{
			string retVal = null;
			if (list_mungableItems.Count > 0)
			{
				List<MungableItem> configs = new List<MungableItem>();
				List<MungableItem> scripts = new List<MungableItem>();
				List<MungableItem> textures = new List<MungableItem>();
				List<MungableItem> lvls = new List<MungableItem>();
				StringBuilder builder = new StringBuilder(200);
				foreach (MungableItem item in list_mungableItems)
				{
					if (item.Path.EndsWith(".tga", StringComparison.InvariantCultureIgnoreCase) ||
						item.Path.EndsWith(".texture", StringComparison.InvariantCultureIgnoreCase))
						textures.Add(item);
					else if (item.Path.EndsWith(".lua", StringComparison.InvariantCultureIgnoreCase) ||
							 item.Path.EndsWith(".script", StringComparison.InvariantCultureIgnoreCase))
						scripts.Add(item);
					else if (item.Path.EndsWith(".mcfg", StringComparison.InvariantCultureIgnoreCase) || // TODO: add the other config types
							 item.Path.EndsWith(".config", StringComparison.InvariantCultureIgnoreCase))
						configs.Add(item);
					else if (item.Path.EndsWith(".lvl", StringComparison.InvariantCultureIgnoreCase))
						lvls.Add(item);
				}
				builder.Append("ucft\n{\n");
				if (configs.Count > 0)
				{
					builder.Append("  REQN\n");
					builder.Append("  {\n");
					builder.Append("    \"config\"\n");
					for (int i = 0; i < configs.Count; i++)
					{
						builder.Append(string.Format(
								   "    \"{0}\"\n", configs[i].MungedName));
					}
					builder.Append("  }\n");
				}
				if (scripts.Count > 0)
				{
					builder.Append("  REQN\n");
					builder.Append("  {\n");
					builder.Append("    \"script\"\n");
					for (int i = 0; i < scripts.Count; i++)
					{
						builder.Append(string.Format(
								   "    \"{0}\"\n", scripts[i].MungedName));
					}
					builder.Append("  }\n");
				}
				if (textures.Count > 0)
				{
					builder.Append("  REQN\n");
					builder.Append("  {\n");
					builder.Append("    \"texture\"\n");
					for (int i = 0; i < textures.Count; i++)
					{
						builder.Append(string.Format(
								   "    \"{0}\"\n", textures[i].MungedName));
					}
					builder.Append("  }\n");
				}
				if (lvls.Count > 0)
				{
					builder.Append("  REQN\n");
					builder.Append("  {\n");
					builder.Append("    \"lvl\"\n");
					for (int i = 0; i < lvls.Count; i++)
					{
						builder.Append(string.Format(
								   "    \"{0}\"\n", lvls[i].MungedName));
					}
					builder.Append("  }\n");
				}
				builder.Append("}");
				retVal = builder.ToString();
			}
			return retVal;
		}
	}

	public class MungableItem
	{
		public string Path { get; private set; }
		public string FileName { get; private set; }
		public string MungedName { get; private set; }

		public MungableItem(string path)
		{
			Path = path;
			int targetIndex = path.LastIndexOf('\\') + 1;
			FileName = path.Substring(targetIndex);
			targetIndex = FileName.LastIndexOf(".");
			MungedName = FileName.Substring(0, targetIndex);
		}

		public override string ToString()
		{
			return FileName;
		}
	}
}
