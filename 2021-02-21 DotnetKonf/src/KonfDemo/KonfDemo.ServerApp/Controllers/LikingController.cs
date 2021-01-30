using KonfDemo.ServerApp.Entities;
using KonfDemo.Shared.Models.Liking;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;

namespace KonfDemo.ServerApp.Controllers
{
    [Route("api/liking")]
    public class LikingController : AbpController
    {
        private readonly IRepository<LikeRecord, string> _likeRecordRepository;

        public LikingController(IRepository<LikeRecord, string> likeRecordRepository)
        {
            _likeRecordRepository = likeRecordRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<LikingDto> GetAsync(string id)
        {
            var likeRecord = await _likeRecordRepository.FindAsync(id);

            if (likeRecord == null)
            {
                return LikingDto.Empty;
            }

            return new LikingDto
            {
                LikeCount = likeRecord.LikeCount,
                DislikeCount = likeRecord.DislikeCount
            };
        }

        [HttpPost]
        [Route("{id}/like")]
        public async Task<LikingDto> LikeAsync(string id)
        {
            var likeRecord = await _likeRecordRepository.FindAsync(id);

            if (likeRecord == null)
            {
                likeRecord = new LikeRecord(id)
                {
                    LikeCount = 1
                };

                await _likeRecordRepository.InsertAsync(likeRecord);
            }
            else
            {
                likeRecord.LikeCount++;
                await _likeRecordRepository.UpdateAsync(likeRecord);
            }

            return new LikingDto
            {
                LikeCount = likeRecord.LikeCount,
                DislikeCount = likeRecord.DislikeCount
            };
        }

        [HttpPost]
        [Route("{id}/dislike")]
        public async Task<LikingDto> DislikeAsync(string id)
        {
            var likeRecord = await _likeRecordRepository.FindAsync(id);

            if (likeRecord == null)
            {
                likeRecord = new LikeRecord(id)
                {
                    DislikeCount = 1
                };

                await _likeRecordRepository.InsertAsync(likeRecord);
            }
            else
            {
                likeRecord.DislikeCount++;
                await _likeRecordRepository.UpdateAsync(likeRecord);
            }

            return new LikingDto
            {
                LikeCount = likeRecord.LikeCount,
                DislikeCount = likeRecord.DislikeCount
            };
        }
    }
}
