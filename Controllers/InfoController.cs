using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using app_mysql.Models;
using app_mysql.Services;
using System.Diagnostics;

using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace app_mysql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController  : ControllerBase
    {
        
    [HttpGet]
    public ActionResult<List<Info>> GetAll() =>
    InfoService.GetAll();


    [HttpPost]
    public IActionResult Create(Info info)
    {
        InfoService.Add(info);
        return CreatedAtAction(nameof(Create), new { id = info.id }, info);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Info info)
    {
        if (id != info.id)
            return BadRequest();

        var existingInfo = InfoService.Get(id);
        if(existingInfo is null)
           return NotFound();

        InfoService.Update(info);           
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var info = InfoService.Get(id);
        if (info is null)
            return NotFound();

        InfoService.Delete(id);
        return NoContent();
    }



    }
}