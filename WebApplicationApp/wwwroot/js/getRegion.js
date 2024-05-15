$(function () {
    $("#areaDropdown").$(function () {
        var areaId = $(this).val();
        var srcUrl = "https://localhost:44389/api/Region/GetRegion/";
        $.ajax({
            url: srcUrl + areaId + "/byAreaID",
            type: "GET",
            crossDomain: true,
            dataType: "json",
            data: { areaId: areaId },
            success: function (data) {
                $("#regionDropdown").empty();
                if (data.length === 0) {
                    $("#regionDropdown").append(
                        $("<option></option>").text("No data").val("")
                    );
                } else {
                    $.each(data, function (index, region) {
                        $("#regionDropdown").append(
                            $("<option></option>")
                                .attr("value", region.regionID)
                                .text(region.regionName)
                        );
                    });
                }
            },
            error: function () {
                alert("Error occurred while fetching locations.");
            },
        });
    });
});
