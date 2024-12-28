using Microsoft.AspNetCore.Mvc;

namespace BlacklogBuster.Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BacklogSyncServiceController : Controller
    {
        private readonly BacklogSyncService _backlogSyncService;
        public BacklogSyncServiceController(BacklogSyncService backlogSyncService)
        {
            _backlogSyncService = backlogSyncService;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncBacklogAsync([FromBody] SyncRequest request)
        {
            try
            {
                await _backlogSyncService.SyncBacklogAsync(request.SteamId, request.PsnUsername, request.PsnPassword, request.UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
    public class SyncRequest
    {
        public string SteamId { get; set; }
        public string PsnUsername { get; set; }
        public string PsnPassword { get; set; }
        public string UserId { get; set; }
    }
}
