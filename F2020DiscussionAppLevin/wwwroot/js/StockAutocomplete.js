$(document).ready(function () {
    $('#selectedStock').autocomplete({

        source: function (request, response) {
            $.getJSON("/Stock/GetStockDataInJson", request, function (data) {
                response($.map(data, function (item) {

                    return {
                        label: item.StockName,
                        value: item.StockSymbol
                    }//end return function

                })//end map function
                )//end response
            }) //end getJsonFunction
        }//end source function

    });// end autocomplete
}); //end function