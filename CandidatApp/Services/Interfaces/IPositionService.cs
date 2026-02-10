using CandidatApp.Models.Positions;

public interface IPositionService
{
    Task<List<PositionListModel>> GetPositionsAsync();
}
