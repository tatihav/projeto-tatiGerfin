import React, { useState } from "react";

export default function CadastroUsuario() {
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    const novoUsuario = { nome, email, senha };

    fetch("https://localhost:7168/api/usuarios", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(novoUsuario)
    })
     .then(async response => {
  if (!response.ok) {
    const erro = await response.text();
    throw new Error(`Erro ${response.status}: ${erro}`);
  }

  const data = await response.json();
  alert("Usuário cadastrado com sucesso!");
  console.log("Retorno da API:", data);
})
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Cadastro de Usuário</h2>

      <label>Nome:</label>
      <input type="text" value={nome} onChange={(e) => setNome(e.target.value)} />

      <label>Email:</label>
      <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />

      <label>Senha:</label>
      <input type="password" value={senha} onChange={(e) => setSenha(e.target.value)} />

      <button type="submit">Cadastrar</button>
    </form>
  );
}
