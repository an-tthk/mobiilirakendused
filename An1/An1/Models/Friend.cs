using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using SQLite;

namespace An1.Models
{
	[Table("Friends")]
	public class Friend
	{
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string PictureUrl { get; set; }
	}
}
