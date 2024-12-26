$(() => {
    $("#submitButton").on('click', async function () {
        let price = parseFloat($("#answer1").val());  // Corrected selector for answer1
        let purpose = $("#answer2").val();  // Corrected selector for answer2

        if (isNaN(price) || !purpose) {
            $("#status").text("Please provide valid inputs.");
            return;
        }

        try {
            $("#partList").text("Finding Best Parts...");
            $("#submitButton").prop("disabled", true);  // Disable the submit button while fetching

            // Fetch data from the server
            let response = await fetch(`api/pricing/${price}/${purpose}`);
            if (response.ok) {
                let parts = await response.json();
                buildPartList(parts);  // Correct function call to display the data
            } else if (response.status !== 404) {
                let problemJSON = await response.json();  // Fixed typo (problemJson -> problemJSON)
                errorRtn(problemJSON, response.status);  // Corrected typo here as well
            } else {
                $("#status").text("No such path on server");
            }
        } catch (error) {
            $("#status").text(`Error: ${error.message}`);
        } finally {
            $("#submitButton").prop("disabled", false);  // Re-enable the submit button after request is completed
        }
    });

    const buildPartList = (data) => {
        $("#partList").empty(); // Clear the existing list

        // Create and append the header row
        let div = $(`
        <div class="list-group-item text-black row d-flex" id="status" style="background-color: #0078D7;">Parts Info</div>
        <div class="list-group-item row d-flex text-center text-dark" id="heading">
            <div class="col h4">CPU</div>
            <div class="col h4">CPU Fan</div>
            <div class="col h4">GPU</div>
            <div class="col h4">Motherboard</div>
            <div class="col h4">RAM</div>
            <div class="col h4">Power Supply</div>
        </div>
    `);
        div.appendTo($("#partList"));

        // Combine all parts under each category into one column
        const categories = [
            { key: 'cpu', label: 'CPU' },
            { key: 'cooler', label: 'CPU Fan' },
            { key: 'gpu', label: 'GPU' },
            { key: 'motherboard', label: 'Motherboard' },
            { key: 'ram', label: 'RAM' },
            { key: 'psu', label: 'Power Supply' },
        ];

        // Create rows for each category
        const maxParts = Math.max(
            ...categories.map(category => {
                const categoryParts = data[category.key];
                return (categoryParts?.overBudget?.length || 0) + (categoryParts?.underBudget?.length || 0);
            })
        );

        for (let i = 0; i < maxParts; i++) {
            let row = $('<div class="list-group-item row d-flex text-secondary"></div>');

            categories.forEach(category => {
                const categoryParts = data[category.key];
                const allParts = [
                    ...(categoryParts?.overBudget || []),
                    ...(categoryParts?.underBudget || [])
                ];

                const partName = allParts[i]?.name || ''; // Get part name or leave blank
                row.append(`<div class="col text-center">${partName}</div>`);
            });

            $("#partList").append(row);
        }
    };


    // Initial function call could be removed if not required to run on page load
    // buildPartList(); 
});
