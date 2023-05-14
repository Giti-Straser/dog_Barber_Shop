
import React , {useState} from "react";
import db from '../connectToServer'
import { useNavigate } from 'react-router-dom';
import './AddQueue.css';
function AddQueue(){
    const [time, setTime] = useState('');
    const navigate = useNavigate();
    function addQueue(){ 
db.addQueue(time)
alert('added Successfully')
navigate('/queue')
    }
    return(
        <div className="divv">
            <h3 className="line">time you want to come</h3>
            <input className='in4' value={time} type={"datetime-local"} onChange={e => setTime(e.target.value)}/>
            <button className="update" onClick={()=> addQueue()}>Add</button>
        </div>
    )
}
export default AddQueue