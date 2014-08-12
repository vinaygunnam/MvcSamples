module CustomerSearch {
    var txtSearch = $("#txtSearch");
    var resultsContainer = $("#resultsContainer");
    var previousSearch;
    var loader = $("#loader");

    loader.hide();
    resultsContainer.hide();

    var debouncedFn = _.debounce(() => {
        var searchText = txtSearch.val();
        if (searchText && searchText != previousSearch && searchText.length > 2) {
            // make the ajax call
            $.ajax({
                url: "/Customers/Search/QuickSearch",
                type: "POST",
                data: {
                    searchText: searchText
                },
                success: (data: string) => {
                    resultsContainer.html(data);
                },
                error: (xhr: JQueryXHR, status: string, error: string) => {
                    console.log(error);
                },
                beforeSend: () => {
                    loader.show();
                    resultsContainer.hide();
                },
                complete: () => {
                    loader.hide();
                    resultsContainer.show();
                }
            });

            previousSearch = searchText;
        }
    }, 300, false);

    txtSearch.on("keyup", (evt: JQueryEventObject) => {
        debouncedFn();
    });
}