document.addEventListener("DOMContentLoaded", () => {
    const jetList = document.getElementById("jet-list");

    // Fetch jet data
    fetch("/api/Jet")
        .then(response => response.json())
        .then(data => {
            data.forEach(jet => {
                const jetDiv = document.createElement("div");
                jetDiv.innerHTML = `
                    <h3>${jet.model}</h3>
                    <p>Capacity: ${jet.capacity}</p>
                    <p>Price/Hour: $${jet.pricePerHour}</p>
                `;
                jetList.appendChild(jetDiv);
            });
        });

    // Handle contact form submission
    const contactForm = document.getElementById("contact-form");
    contactForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const formData = new FormData(contactForm);
        fetch("/api/Jet/contact", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(Object.fromEntries(formData)),
        })
            .then(response => response.json())
            .then(data => alert(data.message))
            .catch(err => console.error(err));
    });
});
