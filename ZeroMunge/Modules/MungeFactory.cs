using System.Collections.Generic;

namespace ZeroMunge.Modules
{
	public class MungeFactory
	{
		public string CopyToStaging { get; set; }
		public string FileDir { get; set; }
		public string Args { get; set; }
		public string StagingDir { get; set; }
		public string MungeDir { get; set; }
		public List<string> MungedFiles { get; set; }
	}
}
