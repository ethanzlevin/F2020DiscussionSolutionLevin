$(document).ready(function () {
    $('#selectedAddress').autocomplete({

        source: function (request, response) {
            $.getJSON("/Address/GetAddressDataInJson", request, function (data) {
                response($.map(data, function (item) {

                    return {
                        label: item.description,
                        value: item.description
                    }//end return function

                })//end map function
                )//end response
            }) //end getJsonFunction
        }//end source function

    });// end autocomplete
}); //end function