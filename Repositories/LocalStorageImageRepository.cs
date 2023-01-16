namespace StudentAdminPortal.API.Repositories
{
    public class LocalStorageImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string FileName)
        {
            var filePath =Path.Combine(Directory.GetCurrentDirectory(), @"Resources/Images", FileName);
            using Stream filestream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(filestream);
            return GetServerRelativePath(FileName);
        }

        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources/Images", fileName);
        }
    }
}
