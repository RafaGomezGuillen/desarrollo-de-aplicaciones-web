const element = document.querySelector("div");
const input = document.querySelector("input");
const paragraph = document.querySelector("p");
const result = document.querySelector(".result");
const ul = document.querySelector("ul");
let textCopied = [];

// a) Evento de teclado
input.addEventListener("keyup", () => {
  paragraph.innerHTML = `${input.value} 
                        <br /><br /> 
                        Characters typed: ${input.value.length}`;
});

// b) Evento de ClipBoard
element.addEventListener("copy", () => {
  const text = document.createElement("li");
  textCopied.push(input.value);

  // Append al ul
  text.textContent = input.value;
  ul.appendChild(text);
});
