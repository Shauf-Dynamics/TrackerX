import { UserClaims } from "./auth.models";

export class AuthSessionStorage {    

    public storeUser(user: UserClaims | any): void {
        if (user !== null) {
            let userClaim = new UserClaims(user.userName, user.role);
            localStorage.setItem('userClaims', JSON.stringify(userClaim));
        }        
    }

    public removeUser(): void {
        localStorage.removeItem('userClaims');        
    }

    public getCurrentUser(): UserClaims {
        return JSON.parse(localStorage.getItem('userClaims')!) as UserClaims;        
    }
}