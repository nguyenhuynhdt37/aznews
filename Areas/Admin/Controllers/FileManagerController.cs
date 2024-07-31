using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using elFinder.NetCore.Drivers.FileSystem;
using Microsoft.AspNetCore.Http.Extensions;
using elFinder.NetCore;

namespace aznews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileManagerController : Controller
    {
        [Route("/Admin/file-manager")]
        public IActionResult Index()
        {

            return View();
        }
        IWebHostEnvironment _env;
        public FileManagerController(IWebHostEnvironment env)
        {
            _env = env;
        }
        private Connector GetConnector()
        {
            // uploads
            string pathroot = "uploads";
            string requestUrl = "files";
            var driver = new FileSystemDriver();
            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);
            string rootDirectory = Path.Combine(_env.ContentRootPath, pathroot);
            string url = $"/{requestUrl}/";
            string urlthumb = $"{uri.Scheme}://{uri.Authority}/Admin/thumb/";
            var root = new elFinder.NetCore.RootVolume(rootDirectory, url, urlthumb)
            {
                IsReadOnly = false,
                IsLocked = false,
                Alias = "Files",
                //MaxUploadSizeInKb = 2048,
                ThumbnailSize = 100,
            };
            driver.AddRoot(root);
            return new Connector(driver)
            {
                MimeDetect = MimeDetectOption.Internal
            };
        }

        [Route("/Admin/connector")]
        public async Task<IActionResult> Connector()
        {
            var connector = GetConnector();
            return await connector.ProcessAsync(Request);
        }
    }
}