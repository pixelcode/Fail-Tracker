using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FailTracker.Core.Domain;

namespace FailTracker.Web.Models.Issues
{
	public class AddIssueForm
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public IssueType Type { get; set; }

		[Required]
		public PointSize Size { get; set; }

		[Required]
		[DisplayName("Assigned To")]
		[UIHint("UserDropDown")]
		public Guid AssignedTo { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Body { get; set; }
	}
}