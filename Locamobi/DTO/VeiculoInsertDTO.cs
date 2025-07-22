namespace Locamobi_CRUD_Repositories.DTO
{
    public class VeiculoInsertDTO
    {
        public int CodVeiculo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int Cidade_CodCid { get; set; }
        public string Classific { get; set; }
        public string Tipo { get; set; }
        public int Usuario_CodUser { get; set; }

    }
}
