type Props = {
    title: string
    state: string
    handleChange: (event: React.ChangeEvent<HTMLInputElement>) => void
}

const Field = ({ title, state, handleChange }: Props) => {
    return ( 
        <div className='field'>
            <div className='field__title'>
                {title}
            </div>
            <input className='field__input'
                type='text'
                value={state}
                onChange={handleChange}
            />
        </div>
    )
}

export default Field