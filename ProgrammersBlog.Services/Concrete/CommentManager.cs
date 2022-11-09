using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class CommentManager : ManagerBase, ICommentService
    {

        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<CommentDto>> GetAsync(int commentId)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                {
                    Comment = comment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<IDataResult<CommentUpdateDto>> GetCommentUpdateDtoAsync(int commentId)
        {
            var result = await UnitOfWork.Comments.AnyAsync(c => c.Id == commentId);
            if (result)
            {
                var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);
                var commentUpdateDto = Mapper.Map<CommentUpdateDto>(comment);
                return new DataResult<CommentUpdateDto>(ResultStatus.Success, commentUpdateDto);
            }
            else
            {
                return new DataResult<CommentUpdateDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: false), null);
            }
        }

        public async Task<IDataResult<CommentListDto>> GetAllAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(null, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByDeletedAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => c.IsDeleted, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => !c.IsDeleted, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentDto>> AddAsync(CommentAddDto commentAddDto)
        {
            var article = await UnitOfWork.Articles.GetAsync(a => a.Id == commentAddDto.ArticleId);
            if (article == null)
            {
                return new DataResult<CommentDto>(ResultStatus.Error, Messages.ArticleMessage.NotFound(isPlural: false), null);
            }
            var comment = Mapper.Map<Comment>(commentAddDto);
            var addedComment = await UnitOfWork.Comments.AddAsync(comment);
            article.CommentCount += 1;
            await UnitOfWork.Articles.UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, Messages.CommentMessage.Add(commentAddDto.CreatedByName), new CommentDto
            {
                Comment = addedComment,
            });
        }

        public async Task<IDataResult<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedByName)
        {
            var oldComment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentUpdateDto.Id);
            var comment = Mapper.Map<CommentUpdateDto, Comment>(commentUpdateDto, oldComment);
            comment.ModifiedByName = modifiedByName;
            var updatedComment = await UnitOfWork.Comments.UpdateAsync(comment);
            updatedComment.Article = await UnitOfWork.Articles.GetAsync(a => a.Id == updatedComment.ArticleId);
            await UnitOfWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, Messages.CommentMessage.Update(comment.CreatedByName), new CommentDto
            {
                Comment = updatedComment,
            });
        }

        public async Task<IDataResult<CommentDto>> DeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.Article);
            if (comment != null)
            {
                var article = comment.Article;
                comment.IsDeleted = true;
                comment.IsActive = false;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var deletedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                article.CommentCount -= 1;
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.CommentMessage.Delete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<IResult> HardDeleteAsync(int commentId)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.ArticleId);
            if (comment != null)
            {
                if (comment.IsDeleted)
                {
                    await UnitOfWork.Comments.DeleteAsync(comment);
                    await UnitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, Messages.CommentMessage.HardDelete(comment.CreatedByName));
                }
                var article = comment.Article;
                await UnitOfWork.Comments.DeleteAsync(comment);
                article.CommentCount = await UnitOfWork.Comments.CountAsync(c => c.ArticleId == article.Id && !c.IsDeleted);
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.CommentMessage.HardDelete(comment.CreatedByName));
            }
            return new Result(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: false));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var commentsCount = await UnitOfWork.Comments.CountAsync();
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var commentsCount = await UnitOfWork.Comments.CountAsync(c => !c.IsDeleted);
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<CommentDto>> ApproveAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.Article);
            if (comment != null)
            {
                var article = comment.Article;
                comment.IsActive = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var updatedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                article.CommentCount = await UnitOfWork.Comments.CountAsync(c => c.ArticleId == article.Id && !c.IsDeleted);
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.CommentMessage.Approve(commentId), new CommentDto
                {
                    Comment = updatedComment
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<CommentDto>> UndoDeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId, c => c.Article);
            if (comment != null)
            {
                var article = comment.Article;
                comment.IsDeleted = false;
                comment.IsActive = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var deletedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                article.CommentCount += 1;
                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.CommentMessage.UndoDelete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.CommentMessage.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }
    }
}
