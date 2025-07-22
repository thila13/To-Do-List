export async function perdoruesit(): Promise<any[]> {
    try {
        const response = await fetch("/api/Backend/Perdoruesit",{
            method: "GET",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            credentials: "include"
        })
        const users = await response.json()
        return users
    } catch (e) {
        console.error(`Perdoruesit couldn't be fetched ${e}` )
    }
}