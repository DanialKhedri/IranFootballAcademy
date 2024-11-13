using Application.DTOs.Article.AddDTO;
using Application.DTOs.Article.EditDTO;
using Application.DTOs.Article.ReadonlyDTO;
using Application.Services.Interface.Artic;
using Application.Services.Interface.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sample_WebApi_For_Blazort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {



        #region Ctor

        private readonly IArticleService _articleService;
        private readonly IUserService _userservice;
        public ArticleController(IArticleService articleService, IUserService userservice)
        {
            _articleService = articleService;
            _userservice = userservice;
        }


        #endregion




        [HttpGet("[Action]")]
        public async Task<ActionResult<List<ArticleReadonlyDTO>>> GetAllArticles()
        {



            var article = await _articleService.GetAllArticle();

            return Ok(article);


        }


        //Get By Id readonlydto
        [HttpGet("[Action]")]
        public async Task<ActionResult<ArticleReadonlyDTO>> GetArticleById(int Id)
        {


            if (Id <= 0)
                return BadRequest();


            var article = await _articleService.GetArticleById(Id);


            if (article == null)
                return BadRequest();


            return Ok(article);

        }


        //Add  adddto
        [Authorize]
        [HttpPost("[Action]")]
        public async Task<ActionResult<bool>> AddArticle(ArticleAddDTO dto)
        {

            var isadmin = await AdminCheck();

            if (!isadmin)
                return Forbid();


            if (!ModelState.IsValid)
                return BadRequest();


            var result = await _articleService.AddArticle(dto);

            if (result)
                return Ok(result);

            else
                return StatusCode(500, result);



        }


        [Authorize]
        [HttpPatch("[Action]")]
        //Edit editdto
        public async Task<ActionResult<bool>> EditArticle(ArticleEditDTO dto)
        {
            var isadmin = await AdminCheck();

            if (!isadmin)
                return Forbid();

            if (!ModelState.IsValid)
                return BadRequest();


            var result = await _articleService.EditArticle(dto);

            if (result)
                return Ok();

            else
                return StatusCode(500, result);


        }


        [Authorize]
        [HttpPost("[Action]")]
        //Remove
        public async Task<ActionResult<bool>> RemoveArticle(int Id)
        {


            var isadmin = await AdminCheck();

            if (!isadmin)
                return Forbid();




            if (Id <= 0)
                return BadRequest();


            var result = await _articleService.RemoveArticle(Id);

            if (result)
                return Ok(result);

            else
                return StatusCode(500, result);



        }







        private async Task<bool> AdminCheck()
        {



            //Admin Check
            var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIid == null)
                return false;

            var isadmin = await _userservice.UserIsAdmin(int.Parse(userIid));
            if (!isadmin)
                return false;


            return true;
        }

    }

}
