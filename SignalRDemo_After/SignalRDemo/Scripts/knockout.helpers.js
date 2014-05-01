(function() {

    window.mapToObservable = function(dto) {
        var mapped = {};
        for (var prop in dto) {
            if (dto.hasOwnProperty(prop)) {
                mapped[prop] = ko.observable(dto[prop]);
            }
        }

        return mapped;
    };

    ko.bindingHandlers.currency = {
        update: function(element, valueAccessor) {
            var amount = parseFloat(ko.utils.unwrapObservable(valueAccessor())) || 0;

            var newValueAccessor = function() {
                return amount.toFixed(0) + " SEK";
            };

            ko.bindingHandlers.text.update(element, newValueAccessor);
        }
    };

    ko.bindingHandlers.highlight = {
        init: function (element, valueAccessor, allBindings) {
        },
        update: function (element, valueAccessor, allBindings) {
            var value = valueAccessor();
            if (value()) {
                var c = allBindings.get('highlightClass');
                $(element).addClass(c);
                $(element).focus();
                $(element).removeClass(c);
            }
        }
    };
})();
