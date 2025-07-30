import { Link} from "react-router-dom"
import Container from "./Container"
import styles from './Navbar.module.css'
import logo from '../../img/th_logo.jpg'

function Navbar () {
return(
    <nav className={styles.navbar}>
        <Container>
            <Link to="/">
            <img className={styles.logo} src={logo} alt="ProjetoTati" />
            </Link>
            <ul className={styles.list}>     
          <li className={styles.item}> <Link to="/">Home</Link> </li>
          <li className={styles.item}> <Link to="/despesas">Despesas</Link> </li>
          <li className={styles.item}> <Link to="/rendas">Rendas</Link> </li> 
          <li className={styles.item}> <Link to="/relatorios">Relatórios</Link> </li>
           <li className={styles.item}> <Link to="/usuario">CadastroUsuario</Link> </li>

           </ul>
        </Container>
    </nav>

)

}
export default Navbar