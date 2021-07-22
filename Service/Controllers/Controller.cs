using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace Service.Controllers 
{
	[Route("api/controller")]
	[ApiController]
	public class Controller : ControllerBase 
	{
		public Controller() 
		{

		}
		[HttpGet("{table}")]
		[ProducesResponseType(typeof())]
		public HttpResponseMessage GetTable(string table) {
			try 
			{

				Reader repo = new Reader(table);
				var result = repo.GetAllRows();
				return Request.CreateResponse(HttpStatusCode.OK, result);		

			} catch (Exception ex) 
			{
        return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}
		}
	}
}