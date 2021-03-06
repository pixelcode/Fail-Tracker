﻿using System.Web.Mvc;

namespace FailTracker.Web.ActionResults
{
	public static class StatusMessageExtensions
	{
		public static ActionResult WithErrorMessage(this ActionResult innerResult, string message)
		{
			return StatusResult.Decorate(innerResult, message, StatusType.Error);
		}

		public static ActionResult WithSuccessMessage(this ActionResult innerResult, string message)
		{
			return StatusResult.Decorate(innerResult, message, StatusType.Success);
		}		
	}

	public enum StatusType
	{
		Error,
		Success
	}

	public class StatusResult : ActionResult
	{
		public ActionResult InnerResult { get; private set; }

		public string Message { get; set; }

		public StatusType Type { get; set; }

		public static StatusResult Decorate(ActionResult innerResult, string message, StatusType type)
		{
			return new StatusResult(innerResult, message, type);
		}

		private StatusResult(ActionResult innerResult, string message, StatusType type)
		{
			InnerResult = innerResult;
			Message = message;
			Type = type;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			context.Controller.TempData["StatusMessage"] = Message;
			context.Controller.TempData["StatusMessageType"] = Type.ToString().ToLower();
			InnerResult.ExecuteResult(context);
		}
	}
}