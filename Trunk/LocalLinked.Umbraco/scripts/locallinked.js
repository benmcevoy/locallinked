var locallinked = function () {
    "use strict"
    var init = function (options) {

    };

    var renderPieChart = function (dataUrl, title, renderTo) {
        var options = {
            chart: {
                renderTo: renderTo,
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false
            },
            credits: {
                enabled: false
            },
            title: {
                text: title
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.point.name + '</b>: ' + this.percentage + ' %';
                }
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        color: '#000000',
                        connectorColor: '#000000',
                        formatter: function () {
                            return '<b>' + this.point.name + '</b>: ' + this.percentage + ' %';
                        }
                    }
                }
            },
            series: [{
                type: 'pie',
                name: title
            }]
        };

        $.getJSON(dataUrl, function (data) {

            var results = [];

            $.each(data.Frequencies, function (index, val) {
                if (val.Key == '') {
                    val.Key = 'unspecified';
                }

                results.push([val.Key, val.Value]);
            });

            options.series[0].data = results;

            var chart = new Highcharts.Chart(options);
        });
    };


    return {
        init: init,
        renderPieChart: renderPieChart
        // expose more public methods
    };
} ();