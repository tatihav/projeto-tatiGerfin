import { HashRouter as Router, Routes, Route,} from 'react-router-dom'
import Home from './components/pages/Home';
import Despesas from './components/pages/Despesas';
import Rendas from './components/pages/Rendas';
import Relatorios from './components/pages/Relatorios';
import CadastroUsuario from './components/pages/CadastroUsuario';

import Container from './components/layout/Container';
import Navbar from './components/layout/Navbar';
import Footer from './components/layout/Footer';



function App() {
  return (
    
        <Router>
          <Container customClass="min-height">
            <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/despesas" element={<Despesas />} />
          <Route path="/rendas" element={<Rendas />} />
          <Route path="/relatorios" element={<Relatorios />} />
          <Route path="/usuario" element={<CadastroUsuario />} />

        </Routes>
        </Container>
      <Footer />
       
      
      </Router>
      );
    }
    


export default App;
