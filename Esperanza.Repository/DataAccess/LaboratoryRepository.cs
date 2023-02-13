using Dapper;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.SPs;
using Esperanza.Repository.Constants;
using Microsoft.Extensions.Options;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratoryRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;
        private readonly IImageService ImageService;
        private readonly ImageOptions Options;

        public LaboratoryRepository(
            IConnectionBuilder connectionBuilder,
            IImageService imageService,
            IOptions<ImageOptions> options
            ) : base(Table.Laboratory, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
            ImageService = imageService;
            Options = options.Value;
        }

        public async Task<List<Laboratory>> GetAll()
        {
            List<Laboratory> laboratories;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                laboratories = (await db.QueryAsync<Laboratory, Image, Laboratory>(
                Laboratory.GetAll, (laboratory, image) =>
                {
                    laboratory.Image = image;
                    laboratory.Image.Base64Image = ImageService.GetBase64RangeImage(Options.Laboratory, laboratory.IdImage.ToString());
                    return laboratory;
                }, splitOn: "Guid")).ToList();
            }
            return laboratories;
        }

        public async Task<List<LaboratorySp>> GetAllSp(Pagination pagination)
        {
            List<LaboratorySp> labs;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                labs = db.Query<LaboratorySp>("GetAllLaboratoriesPagination", new { Start = pagination.Start },
                            commandType: CommandType.StoredProcedure).ToList();
            }
            await Parallel.ForEachAsync(labs, async (lab, cancellationToken) =>
            {
                lab.Base64Image = ImageService.GetBase64RangeImage(Options.Laboratory, lab.IdImage.ToString());
            });
            return labs;
        }

        public async Task<List<Laboratory>> GetTopFive()
        {
            List<Laboratory> laboratories;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                laboratories = (await db.QueryAsync<Laboratory, Image, Laboratory>(
                Laboratory.GetTopFive, (laboratory, image) =>
                {
                    laboratory.Image = image;
                    laboratory.Image.Base64Image = ImageService.GetBase64RangeImage(Options.Laboratory, laboratory.IdImage.ToString());
                    return laboratory;
                }, splitOn: "Guid")).ToList();
            }
            return laboratories;
        }

        public async Task<Laboratory> GetById(string id)
        {
            Laboratory laboratory;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                laboratory = (await db.QueryAsync<Laboratory, Image, Laboratory>(
                Laboratory.GetById, (laboratory, image) =>
                {
                    laboratory.Image = image;
                    laboratory.Image.Base64Image = ImageService.GetBase64RangeImage(Options.Laboratory, laboratory.IdImage.ToString());
                    return laboratory;
                }, new { IdLaboratory = id }, splitOn: "Guid")).FirstOrDefault();
            }
            return laboratory;
        }
    }
}
