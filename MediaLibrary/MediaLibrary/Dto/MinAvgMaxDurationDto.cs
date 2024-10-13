namespace MediaLibrary.Domain.Dto;
/// <summary>
/// DTO for representing the minimum, average, and maximum duration of albums.
/// </summary>
public class MinAvgMaxDurationDto
{
    /// <summary>
    /// The minimum duration of albums.
    /// </summary>
    public double Min { get; set; }


    /// <summary>
    /// The average duration of albums.
    /// </summary>
    public double Avg { get; set; }

    /// <summary>
    /// The maximum duration of albums.
    /// </summary>
    public double Max { get; set; }
}
