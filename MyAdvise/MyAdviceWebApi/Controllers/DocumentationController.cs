using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models.Models;
using DataAccessLayer;
using DataAccessLayer.ViewModels.ViewModels;

namespace MyAdviceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public DocumentationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Gets all the documentation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DocumentationVM> GetDocumentation()
        {
            var documentation = uow.Documentation.FindAll(null, x => x.User);
            IEnumerable<DocumentationVM> documentationVM = documentation.Select(x => new DocumentationVM(x));
            return documentationVM;
        }

        /// <summary>
        /// Gets all the Documentation with the User's Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userId")]
        public IEnumerable<DocumentationVM> GetDocumentationByUserId(int userId)
        {
            var documentation = uow.Documentation.FindAll(x => x.UserId == userId);
            IEnumerable<DocumentationVM> documentationVM = documentation.Select(x => new DocumentationVM(x));
            return documentationVM;
        }

        /// <summary>
        /// Inserts a new Documentation on the database
        /// </summary>
        /// <param name="documentationVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertDocumentation(DocumentationVM documentationVM)
        {
            try
            {
                Documentation documentation = new Documentation()
                {
                    DocumentationId = documentationVM.DocumentationId,
                    Name = documentationVM.Name,
                    DescriptionA = documentationVM.DescriptionA,
                    DescriptionB = documentationVM.DescriptionB,
                    Link = documentationVM.Link,
                    RegisterDate = DateTime.Now,
                    UserId = documentationVM.UserId,
                    DocumentationCheck = false,
                    LinkB = documentationVM.LinkB
                };

                if (documentationVM != null)
                {
                    uow.Documentation.Insert(documentation);
                    uow.Commit();
                    return Ok(documentation);
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        /// <summary>
        /// Updates the Document on the DataBase
        /// </summary>
        /// <param name="documentationVM"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateDocumentation(DocumentationVM documentationVM)
        {
            try
            {
                if (uow.Documentation.FindAll(x => x.DocumentationId == documentationVM.DocumentationId) != null)
                {
                    Documentation documentation = new Documentation() {
                        DocumentationId = documentationVM.DocumentationId,
                        Name = documentationVM.Name,
                        DescriptionA = documentationVM.DescriptionA,
                        DescriptionB = documentationVM.DescriptionB,
                        Link = documentationVM.Link,
                        UserId = documentationVM.UserId,
                        DocumentationCheck = documentationVM.DocumentationCheck,
                        LinkB = documentationVM.LinkB
                    };
                    uow.Documentation.Update(documentation);
                    uow.Commit();
                    return Ok(documentation);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
