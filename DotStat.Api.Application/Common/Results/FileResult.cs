namespace DotStat.Api.Application.Common.Results;

public record FileResult(byte[] Body, string FileName);