
import React,{ useState } from "react";
import './UpdateQueue.css'
import db from '../connectToServer'
import { useNavigate } from 'react-router-dom';
function UpdateQueue(){
    const queueId = db.c.queue.queueId;
    const [time, setTime] = useState('');
    const navigate = useNavigate();
    function updateQueue(){
        db.updateQueue(queueId,time)
        alert('updated Successfully')
        navigate('/queue')
    }
    return(
        <div className="divv">
            <h3 className="line">time you want to come</h3>
            <input className='in3' value={time} type={"datetime-local"} onChange={e => setTime(e.target.value)}/>
            <button className="update" onClick={updateQueue}>update</button>
        </div>
    )
}
export default UpdateQueue