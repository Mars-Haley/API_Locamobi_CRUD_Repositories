namespace Models;

public record VeiculoInfo(int CodVeiculo, string Modelo,
    string Marca, int Ano, string Placa, string Cor, 
    int Cidade_CodCid, string Classific, string Tipo, 
    int Usuario_CodUser);