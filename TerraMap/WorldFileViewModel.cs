﻿using System.IO;
using TerraMap.Data;

namespace TerraMap
{
	public class WorldFileViewModel : ViewModelBase
	{
		private FileInfo fileInfo;

		public FileInfo FileInfo
		{
			get { return fileInfo; }
			set
			{
				fileInfo = value;
				RaisePropertyChanged();
			}
		}

		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				RaisePropertyChanged();
			}
		}

		private bool cloud;

		public bool Cloud
		{
			get { return cloud; }
			set
			{
				cloud = value;
				RaisePropertyChanged();
			}
		}
	}
}
