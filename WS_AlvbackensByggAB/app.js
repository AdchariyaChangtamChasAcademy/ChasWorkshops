// REFERENCES DATA
const references = [
  { title: "Takbyte, Vännäs", text: "Tydligt upplägg och bra kommunikation. Allt höll tidsplanen." },
  { title: "Altan, Vindeln", text: "Noggrant arbete och rent på arbetsplatsen varje dag." },
  { title: "Fönsterbyte, Lycksele", text: "Tryggt och proffsigt från första kontakt till färdigt." }
];

const refContainer = document.getElementById("references-container");

references.forEach(ref => {
  const card = document.createElement("div");
  card.classList.add("reference-card");
  card.innerHTML = `<h3>${ref.title}</h3><p>"${ref.text}"</p>`;
  refContainer.appendChild(card);
});

// FORM HANDLING
const form = document.getElementById("contact-form");
const feedback = document.getElementById("form-feedback");

form.addEventListener("submit", e => {
  e.preventDefault();

  // Basic validation
  if (!form.name.value || !form.email.value || !form.message.value) {
    feedback.textContent = "Vänligen fyll i alla fält.";
    return;
  }

  // Fake submit
  feedback.textContent = "Tack! Vi återkommer inom kort.";
  form.reset();
});
