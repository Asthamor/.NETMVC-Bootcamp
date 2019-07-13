$(document).ready(() => {



    $('#productAutoComplete').autocomplete({
        serviceUrl: ,
        onSelect: function (suggestion) {
            alert('You selected: ' + suggestion.value + ', ' + suggestion.data);
        }
    });
})