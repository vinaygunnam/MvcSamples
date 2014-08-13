var CustomerSearch;
(function (CustomerSearch) {
    var txtSearch = $("#txtSearch");
    var resultsContainer = $("#resultsContainer");
    var previousSearch;
    var loader = $("#loader");

    loader.hide();
    resultsContainer.hide();

    var debouncedFn = _.debounce(function () {
        var searchText = txtSearch.val();
        if (searchText && searchText != previousSearch && searchText.length > 2) {
            // make the ajax call
            $.ajax({
                url: "/Customers/Search/QuickSearch",
                type: "POST",
                data: {
                    searchText: searchText
                },
                success: function (data) {
                    resultsContainer.html(data);
                },
                error: function (xhr, status, error) {
                    console.log(error);
                },
                beforeSend: function () {
                    loader.show();
                    resultsContainer.hide();
                },
                complete: function () {
                    loader.hide();
                    resultsContainer.show();
                }
            });

            previousSearch = searchText;
        }
    }, 300, false);

    txtSearch.on("keyup", function (evt) {
        debouncedFn();
    });
})(CustomerSearch || (CustomerSearch = {}));
//# sourceMappingURL=search.js.map
