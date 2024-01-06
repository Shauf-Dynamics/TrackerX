export class UserClaims {
    public userName: string;
    public role: string;
    
    constructor(userName: string, role: string) {        
        this.userName = userName;
        this.role = role;
    }
}
